namespace TreeDrawing


module Types =
  type 'a Tree = Node of 'a * ('a Tree list)

  type Extent = (float * float) list

  let emptyTree rootNodeVal= Node (rootNodeVal,[])



//let completeBinaryTree n =
//    let halfAndCeiling n = int(ceil (float(n)/2.0))
//    let halfAndFloor n = int(floor (float(n)/2.0))
//    let rec inner tree n =
//        match tree,n with
//            | _,0                                                   -> L
//            | L,1                                                   -> B(L,"x",L)
//            | B (L,value,L) as node,1                               -> B(B(L,"x",L),value,L)
//            | B (B(_,_,_) as node,value,L),1                        -> B(node,value,B(L,"x",L))
//
//            | L,2                                                   -> B(B(L,"x",L),"x",L)
//            | B (L,value,L) as node,2                               -> B(B(L,"x",L),value,B(L,"x",L))
//            | B (B(_,_,_) as node,value,L),2                        -> B((inner node 1),value,B(L,"x",L))
//
//            // Each recursion prints half of the remaining nodes,
//            // which is why we di
//            | L,k                                                   -> B(inner L (halfAndCeiling (k-1)),"x",inner L (halfAndFloor (k-1)))
//            | B (L,value,L) as node,k                               -> B(inner L (halfAndCeiling (k-1)),"x",inner L (halfAndFloor (k-1)))
//            | B (B(_,_,_) as node,value,L),k                        -> B(inner node (halfAndCeiling (k-1)),"x",inner L (halfAndFloor (k-1)))
//            | k,x                                                   ->
//                let _ = (printfn "%A ::::: %A" k x)
//                L
//    in
//        inner  L n
