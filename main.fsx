#load "Types.fs"
#load "TreeDesign.fs"
#load "TreeGeneration.fs"
#load "TreeDraw.fs"

open System.IO

open TreeDrawing.Types
open TreeDrawing.TreeDesign
open TreeDrawing.TreeGeneration
open TreeDrawing.Drawing

let someTree = Node (("A",2.0),[Node (("B",3.0),[]);Node (("C",4.0),[])])
let someTree2 = Node ("A",[Node ("B",[Node ("D",[]);Node ("E",[])]);Node ("C",[])])
let someTree3 = Node ("A",[Node ("B",[]);Node ("C",[])])



let hugeTree = TreeDrawing.TreeGeneration.generateRandomTree (3,7) 7
//printfn "%A" (design hugeTree)
TreeDrawing.Drawing.drawTreePS hugeTree "testout.ps"
