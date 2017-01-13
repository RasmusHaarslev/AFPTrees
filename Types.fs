namespace TreeDrawing


module Types =
  type 'a Tree = Node of 'a * ('a Tree list)

  type Extent = (float * float) list

  let emptyTree rootNodeVal= Node (rootNodeVal,[])
