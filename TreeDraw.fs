namespace TreeDrawing

open System.IO

open TreeDrawing.TreeDesign
open TreeDrawing.Types

module Drawing =

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
