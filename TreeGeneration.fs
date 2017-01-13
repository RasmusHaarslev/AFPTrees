namespace TreeDrawing

open TreeDrawing.Types

module TreeGeneration =


  let generateCompleteTree levels bfactor =
    let rec inner tree levels =
      match tree,levels with
        | _,0       -> tree
        | Node (l,[]),n    -> (Node (l,(List.map (fun x -> inner (Node (n-1,[])) (n-1))  [1 .. bfactor])))
        | _,_       -> (sprintf "Should not be here. tree: %A, levels: %A" tree levels) |> failwith
    in
      inner (Node(levels,[])) levels

  let generateRandomTree (minBFactor : int,maxBFactor : int) (maxDepth : int)=
    let rnd = System.Random()
    let rec inner tree maxDepth =
      let thisBFactor = rnd.Next(minBFactor,maxBFactor)
      match tree,maxDepth with
        | _,0       -> tree
        | Node (l,[]),n    -> (Node (l,(List.map (fun x -> inner (Node (maxDepth,[])) (rnd.Next(0,maxDepth-1)))  [1 .. thisBFactor])))
        | _,_       -> (sprintf "Should not be here. tree: %A" tree) |> failwith 
    in
      inner (Node(maxDepth,[])) maxDepth
