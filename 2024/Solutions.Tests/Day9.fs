module Day9

open NUnit.Framework

let input = @"2333133121414131402"

[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day9.resolvePart1 arr
    Assert.AreEqual(1928, result)

[<Test>]
let Test2 () =
    let arr = input.Split('\n')

    let result = Day9.resolvePart2 arr
    Assert.AreEqual(2858, result)
