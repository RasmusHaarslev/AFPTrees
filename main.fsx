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

#time "on";;
let hugeTree = TreeDrawing.TreeGeneration.generateCompleteTree 7 7
//printfn "%A" (design hugeTree)
TreeDrawing.Drawing.drawTreePS hugeTree "testout.ps"


//let k = (parseFromFile("test_programs/QuickSortV2.gc"))
//let b = convertProg k
//drawTreePS b "testout.ps"
