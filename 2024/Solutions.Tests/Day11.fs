module Day11

open NUnit.Framework

let input = @"125 17"

[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day11.resolvePart1 arr
    Assert.AreEqual(55312, result)
