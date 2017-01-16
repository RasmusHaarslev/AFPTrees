namespace TreeDrawing

open TreeDrawing.TreeDesign
open TreeDrawing.Types

module Drawing =

    let drawLeaf node depth =
        printfn "Depth: %A - Node: %A at position: %A" depth (fst node) (snd node)

    let drawParent node depth =
        printfn "Depth: %A - Node: %A at position: %A" depth (fst node) (snd node)

    let drawTree tree =
        let treeDesign = TreeDrawing.TreeDesign.design tree
        in
            let rec drawTree' (Node (n, cs)) depth  =
                match cs with
                | []    ->  drawLeaf n depth
                | x     ->  List.iter (fun y -> drawTree' y (depth+1)) x
                            drawParent n depth
        drawTree' treeDesign 0
