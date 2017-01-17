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

//let hugeTree = TreeDrawing.TreeGeneration.generateCompleteTree 21 2
//let hugeTree = TreeDrawing.TreeGeneration.generateRandomTree (3,3) 30
//ignore(design hugeTree)

//TreeDrawing.Drawing.drawTreePS hugeTree "hugeTree.ps"



let k = (parseFromFile("test_programs/factImpPTyp.gc"))
let b = convertProg k
drawTreePS b "testout.ps"
