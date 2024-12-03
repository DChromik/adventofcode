module Day3

open NUnit.Framework

let input =
    @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"

let input2 =
    @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"

[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day3.resolvePart1 arr
    Assert.AreEqual(161, result)

[<Test>]
let Test2 () =
    let arr = input2.Split('\n')

    let result = Day3.resolvePart2 arr
    Assert.AreEqual(48, result)
