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

//let hugeTree = TreeDrawing.TreeGeneration.generateCompleteTree 8 2
let hugeTree = TreeDrawing.TreeGeneration.generateRandomTree (3,3) 5

let someExtent = [(3.,3.);(4.,7.)]
let someExtent2 = [(9.,10.);(11.,12.)]
let longExtent = [(13.,15.);(15.,19.);(21.,24.)]
// TESTS.
printfn "%A" (moveTree (someTree,3.0))
printfn "%A" ((moveExtent (someExtent,3.0)))
printfn "%A" ((moveExtent (longExtent,3.0)))
printfn "%A" ((merge (someExtent,someExtent2)))
printfn "%A" ((mergeList [someExtent;someExtent2;longExtent]))
printfn "%A" (rmax (2.0,5.0) = 5.0)
printfn "%A" (rmax (7.0,5.0) = 7.0)

printfn "%A" (fit someExtent someExtent2)


// printfn "%A" (TreeDrawing.TreeDesign.moveExtent (someExtent,3.))
// printfn "%A" (TreeDrawing.TreeDesign.merge (someExtent,someExtent2))
// printfn "%A" (TreeDrawing.TreeDesign.mergeList [someExtent;someExtent2])
// printfn "%A" (TreeDrawing.TreeDesign.fit someExtent someExtent2)


//printfn "%A" (TreeDrawing.TreeDesign.design someTree2)

//TreeDrawing.Drawing.drawTreeGustav someTree2

//printfn "%A" (TreeDrawing.TreeDrawing.)

//printfn "%A" (TreeDrawing.TreeDesign.design someTree2)
//TreeDrawing.Drawing.drawTree someTree2 sw
//TreeDrawing.Drawing.drawTreePS someTree2 "testout.ps"
//TreeDrawing.Drawing.drawTreePS hugeTree "testout.ps"
