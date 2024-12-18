module Day8

open NUnit.Framework

let input =
    @"............
........0...
.....0......
.......0....
....0.......
......A.....
............
............
........A...
.........A..
............
............"

[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day8.resolvePart1 arr
    Assert.AreEqual(14, result)

[<Test>]
let Test2 () =
    let arr = input.Split('\n')

    let result = Day8.resolvePart2 arr
    Assert.AreEqual(34, result)
