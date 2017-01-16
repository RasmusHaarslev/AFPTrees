namespace TreeDrawing

open TreeDrawing.Types

module TreeDesign =
  let moveTree ((Node ((l,xPos),childs)),x) = (Node ((l,xPos+x),childs))

  let moveExtent ((e : Extent),x) =
      List.map (fun (p,q) -> (p+x,q+x)) e

  // Merge two extents
  let rec merge (ps,qs) =
    match ps,qs with
      | [],qs   -> qs
      | ps,[]   -> ps
      | ((p,_)::ps,(_,q)::qs) -> (p,q)::(merge(ps,qs))

  // Merge n extents
  let mergeList es = List.fold (fun acc e -> merge(acc,e)) [] es

  // Fitting functions
  let rmax ((p : float),(q : float)) = if p > q then p else q


  let rec fit e1 e2 =
    match e1,e2 with
      | ((_,p)::ps),((q,_)::qs) -> rmax (fit ps qs,(p - q + 1.0))
      | _ -> 0.0

  let fitlistl es =
    let rec fitlistl'  acc ls =
      match acc,ls with
        | acc,[]      -> []
        | acc,e::es   ->
          let x = fit acc e
          in
            x :: (fitlistl' (merge (acc,(moveExtent (e,x)))) es)
    in
      fitlistl' [] es

  let fitlistr es =
    let rec fitlistr'  acc ls =
      match acc,ls with
        | acc,[]      -> []
        | acc,e::es   ->
          let x = -(fit acc e)
          in
            x :: (fitlistr' (merge (acc,(moveExtent(e,x)))) es)
    in
      List.rev (fitlistr' [] (List.rev es))

  let mean (x,y) = (x + y) / 2.0

  let fitlist es = List.map mean (List.zip (fitlistr es) (fitlistl es))

  // Design
  let design tree =
    let rec design' (Node(label,subtrees)) =
      let (trees,extents) = List.unzip (List.map design' subtrees)
      let positions = fitlist extents
      let ptrees = List.map moveTree (List.zip trees positions)
      let pextents = List.map moveExtent (List.zip extents positions)
      let resultextent = (0.,0.) :: (mergeList pextents)
      let resulttree = Node((label,0.),ptrees)
      in
        (resulttree,resultextent)
    in
      fst (design' tree)






























  let f a = a
