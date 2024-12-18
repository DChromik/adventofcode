module Day12

open NUnit.Framework

let input =
    @"RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE"

[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day12.resolvePart1 arr
    Assert.AreEqual(1930, result)

[<Test>]
let Test2 () =
    let arr = input.Split('\n')

    let result = Day12.resolvePart2 arr
    Assert.AreEqual(0, result)
