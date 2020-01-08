module Tests

open System
open Xunit
open FsCheck.Xunit
open ClownLib 

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Property>]
let ``teit`` (foo: int) =
    foo < 10 

