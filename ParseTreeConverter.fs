namespace TreeDrawing

open GuardedCommands.Frontend.AST
open TreeDrawing.Types


module ParseTreeConverter =

    let rec convertProg (P (decls,stms)) =
        let childDecls = List.map convertDec decls
        let childStms = List.map convertStm stms
        Node ("Prog", childDecls @ childStms)

    and convertDec dec =
        match dec with
            | VarDec (t, s) -> Node("VarDec",[Node(s,[convertTyp t])])
            | FunDec (tOpt,s,decl,stm) ->
                let childDecls = List.map convertDec decl
                let stmTree    = convertStm stm
                match tOpt with
                     | None -> Node("FunDec",[Node(s,[]);Node("None",[])] @ childDecls @ [stmTree])
                     | Some t -> Node("FunDec",[Node(s,[]);convertTyp t] @ childDecls @ [stmTree])


    and convertStm stm =
        match stm with
            | PrintLn exp -> Node ("Print", [convertExp exp])
            | Ass (acc, exp) -> Node("Assign",[convertAcc acc] @ [convertExp exp])
            | Return (Some exp)   -> Node("Return",[convertExp exp])
            | Return None   -> Node("Return",[Node("None",[])])
            | Alt (GC gc)        -> Node("Alt",convertGC gc)
            | Do (GC gc)        -> Node("Do",convertGC gc)
            | Block (decl,stml)        ->
                let declTree  = List.map convertDec decl
                let stmTree   = List.map convertStm stml
                Node("Block",declTree @ stmTree)
            | Call (s,expl) ->
                let expTree = List.map convertExp expl
                Node("Call",[Node(s,[])] @ expTree)

    and convertGC gc = List.collect (fun (e,stml) -> [convertExp e] @ (List.map convertStm stml)) gc

    and convertExp exp =
        match exp with
            | N n -> Node(string n,[])
            | B n -> Node(string n,[])
            | Access acc    -> Node("Access",[convertAcc acc])
            | Addr acc      -> Node("Addr",[convertAcc acc])
            | Apply (s,expl) -> Node(s,List.map convertExp expl)

    and convertTyp typ =
        match typ with
            | ITyp  -> Node("ITyp",[])
            | BTyp  -> Node("BTyp",[])
            | ATyp (t,Some i) -> Node("ATyp",[convertTyp t] @ [Node(string i,[])])
            | ATyp (t,None) -> Node("ATyp",[convertTyp t] @ [Node("None",[])])
            | PTyp t    -> Node("PTyp",[convertTyp t])
            | FTyp _    -> Node("FTyp NYI",[])

    and convertAcc acc =
        match acc with
            | AVar s            -> Node(s,[])
            | AIndex (acc,exp)  -> Node("AIndex",[convertAcc acc] @ [convertExp exp])
            | ADeref exp        -> Node("ADeref",[convertExp exp])




























    let k a = 4
