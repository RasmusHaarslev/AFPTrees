namespace TreeDrawing

open System.IO

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

    let drawTreeGustav tree =
        let posTree = tree
        let outFile = "testout.ps"
        let sw = new StreamWriter(outFile)
        sw.WriteLine("%!")
        sw.WriteLine("1 1 scale")
        sw.WriteLine("newpath")
        sw.WriteLine("300 600 moveto")
        sw.WriteLine("350 650 lineto")
        sw.WriteLine("360 660 lineto")
        sw.WriteLine("stroke")
        sw.WriteLine("showpage")
        sw.Close()
