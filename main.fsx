#load "Types.fs"
#load "TreeDrawing.fs"
#load "TreeGeneration.fs"

open TreeDrawing.Types
open TreeDrawing.TreeDrawing
open TreeDrawing.TreeGeneration


//printfn "%A" (Types.generateCompleteTree 4 5)

let someTree = Node (("A",2.0),[])
let someTree2 = Node ("A",[Node ("B",[]);Node ("C",[])])
//printfn "%A" (TreeDrawing.TreeGeneration.generateRandomTree (4,10) 10)

let someExtent = [(3.,3.);(1.,4.)]
let someExtent2 = [(9.,9.);(6.,12.)]

printfn "%A" (TreeDrawing.TreeDrawing.moveExtent (someExtent,3.))
printfn "%A" (TreeDrawing.TreeDrawing.merge (someExtent,someExtent2))
printfn "%A" (TreeDrawing.TreeDrawing.mergeList [someExtent;someExtent2])
printfn "%A" (TreeDrawing.TreeDrawing.fit someExtent someExtent2)


printfn "%A" (TreeDrawing.TreeDrawing.design someTree2)

//printfn "%A" (TreeDrawing.TreeDrawing.)
