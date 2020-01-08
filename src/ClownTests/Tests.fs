module Tests

open Xunit
open FsCheck.Xunit
open ClownLib.Mastermind


[<Fact>]
let ``B R -> (0, 0)``() =
    Assert.Equal((0, 0), diff [Blue] [Red])


[<Fact>]
let ``B B -> (1, 0)``() =
    Assert.Equal((1, 0), diff [Blue] [Blue])

[<Fact>]
let ``RY BR -> (0, 1) ``() =
    Assert.Equal((0, 1), diff [Red; Yellow] [Blue; Red])

[<Fact>]
let ``GBRP YYGG -> (0, 1)``() =
    Assert.Equal((0, 1), diff [Green; Blue; Red; Pink] [Yellow; Yellow; Green; Green])

[<Fact>]
let ``GBRP PRRY -> (1, 1)``() =
    Assert.Equal((1, 1), diff [Green; Blue; Red; Pink] [Pink; Red; Red; Yellow])

[<Fact>]
let ``GBRP GPGY -> (1, 1)``() =
    Assert.Equal((1, 1), diff [Green; Blue; Red; Pink] [Green; Pink; Green; Yellow])

[<Fact>]
let ``GBRP RRPY -> (1, 1)``() =
    Assert.Equal((0, 2), diff [Green; Blue; Red; Pink] [Red; Red; Pink; Yellow])

type FourColors = {a: Color; b:Color; c: Color; d:Color}

[<Property>]
let ``can not be more right than four`` (guess: FourColors) (answer: FourColors) =
    let guess = [guess.a; guess.b; guess.c; guess.d]
    let answer = [answer.a; answer.b; answer.c; answer.d]
    let (foo, bar) = diff answer guess
    let sum = foo + bar
    Assert.True (sum <= 4 && sum >= 0)

[<Property>]
let ``unicolors are easy`` (guess: Color) (answer: Color) =
    let guess = List.replicate 4 guess
    let answer = List.replicate 4 answer
    let (foo, bar) = diff answer guess
    if (guess = answer) then
        Assert.True(foo = 4 && bar = 0)
    else
        Assert.True(foo=0 && bar = 0)

[<Property>]
let ``correct answer are easy``  (guess: FourColors) =
    let guess' = [guess.a; guess.b; guess.c; guess.d]

    let (foo, bar) = diff guess' guess'
    Assert.True(foo = 4 && bar = 0)

[<Property>]
let ``rett er rett og galt er galt`` (guess: FourColors) (answer: FourColors) =
    let guess = [guess.a; guess.b; guess.c; guess.d]
    let answer = [answer.a; answer.b; answer.c; answer.d]
    let (foo, bar) = diff guess guess
    if (guess = answer) then
        Assert.True(foo = 4 && bar = 0)
    else
        Assert.True(bar < 4)
