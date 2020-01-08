module Tests

open System
open Xunit
open ClownLib 

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``My test Lib`` () =
    Assert.Equal(3, ClownLib.Say.yo "22")
