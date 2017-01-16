namespace TreeDrawing

open System.IO

open TreeDrawing.TreeDesign
open TreeDrawing.Types

module Drawing =

    let scale = 40.
    let fontScale = int (scale / 4.)

    let drawLeaf n parX depth (writer : StreamWriter) =
        writer.WriteLine(sprintf "%d %d moveto" (int parX) depth)
        writer.WriteLine(sprintf "(%A) dup stringwidth pop 2 div neg 0 rmoveto show" (fst n))
        writer.WriteLine(sprintf "%d %d moveto" (int parX) (depth+fontScale))
        writer.WriteLine(sprintf "%d %d lineto" (int parX) (depth + int (scale/2.0)))
        //printfn "Depth: %A - Node: %A at position: %A" depth (fst n) (parX)

    let drawParent n cs parX depth (writer : StreamWriter) =
        writer.WriteLine(sprintf "%d %d moveto" (int parX) depth)
        writer.WriteLine(sprintf "(%A) dup stringwidth pop 2 div neg 0 rmoveto show" (fst n))
        writer.WriteLine(sprintf "%d %d moveto" (int parX) (depth+fontScale))
        writer.WriteLine(sprintf "%d %d lineto" (int parX) (depth + int (scale/2.0)))
        let (Node ((_,leftMostPos),_)) = List.head cs
        let (Node ((_,rightMostPos),_)) = List.last cs
        writer.WriteLine(sprintf "%d %d moveto" (int (leftMostPos * scale + parX)) (depth - int (scale/2.0)))
        writer.WriteLine(sprintf "%d %d lineto" (int (rightMostPos * scale + parX)) (depth - int (scale/2.0)))
        writer.WriteLine(sprintf "%d %d moveto" (int parX) (depth - fontScale / 2))
        writer.WriteLine(sprintf "%d %d lineto" (int parX) (depth - int(scale/2.0)))

        //printfn "Depth: %A - Node: %A at position: %A" depth (fst n) (parX)

    let drawTree tree writer =
        let treeDesign = TreeDrawing.TreeDesign.design tree
        in
            let rec drawTree' (Node (n, cs)) parentX depth  =
                let newParX = (snd n * scale) + parentX
                let newDepth = depth - int(scale)
                match cs with
                | []    ->  drawLeaf n newParX depth writer
                | x     ->  List.iter (fun y -> drawTree' y newParX newDepth) x
                            drawParent n cs newParX depth writer

        drawTree' treeDesign 700. 800

    let drawTreePS tree (outFile : string)=
        let sw = new StreamWriter(outFile)
        sw.WriteLine("%!")
        sw.WriteLine("<</PageSize[1400 1000]/ImagingBBox null>> setpagedevice")
        sw.WriteLine("1 1 scale")

        sw.WriteLine("newpath")
        sw.WriteLine(sprintf "/Times-Roman findfont %d scalefont setfont" fontScale)

        drawTree tree sw

        sw.WriteLine("stroke")
        sw.WriteLine("showpage")
        sw.Close()
