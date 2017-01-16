#r @"ParseTreeGeneration/bin/Debug/FSharp.PowerPack.dll";;

#load "ParseTreeGeneration/AST.fs"
#load "Types.fs"
#load "TreeDesign.fs"
#load "TreeGeneration.fs"
#load "TreeDraw.fs"
#load "ParseTreeConverter.fs"

#load "ParseTreeGeneration/Parser.fs"
#load "ParseTreeGeneration/Lexer.fs"
#load "ParseTreeGeneration/Util.fs"

open GuardedCommands.Util.ParserUtil
open GuardedCommands.Frontend.AST

open System.IO

open TreeDrawing.Types
open TreeDrawing.TreeDesign
open TreeDrawing.TreeGeneration
open TreeDrawing.Drawing
open TreeDrawing.ParseTreeConverter

let someTree = Node (("A",2.0),[Node (("B",3.0),[]);Node (("C",4.0),[])])
let someTree2 = Node ("A",[Node ("B",[Node ("D",[]);Node ("E",[])]);Node ("C",[])])
let someTree3 = Node ("A",[Node ("B",[]);Node ("C",[])])



let hugeTree = TreeDrawing.TreeGeneration.generateRandomTree (3,7) 15
//printfn "%A" (design hugeTree)
TreeDrawing.Drawing.drawTreePS hugeTree "testout.ps"


let k = (parseFromFile("test_programs/QuickSortV2.gc"))

#time "on";;
let b = convertProg k
printfn "%A" b
drawTreePS b "testout.ps"
