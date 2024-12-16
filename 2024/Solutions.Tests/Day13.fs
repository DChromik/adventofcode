module Day13

open NUnit.Framework

let input =
    @"p=0,4 v=3,-3
p=6,3 v=-1,-3
p=10,3 v=-1,2
p=2,0 v=2,-1
p=0,0 v=1,3
p=3,0 v=-2,-2
p=7,6 v=-1,-3
p=3,0 v=-1,-2
p=9,3 v=2,3
p=7,3 v=-1,2
p=2,4 v=2,-3
p=9,5 v=-3,-3"


[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day13.testPart1 arr
    Assert.AreEqual(12, result)

[<Test>]
let Test2 () =
    let arr = input.Split('\n')

    let result = Day13.resolvePart2 arr
    Assert.AreEqual(0, result)
