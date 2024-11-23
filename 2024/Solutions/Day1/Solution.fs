module Day1

open System.IO

let resolvePart1 filePath =
    for line in File.ReadLines filePath do
        printfn "%s" line
