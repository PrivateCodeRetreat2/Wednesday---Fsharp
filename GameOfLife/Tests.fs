[<VerifyXunit.UsesVerify>]
module Tests

open Xunit
open VerifyTests
open VerifyXunit
open Newtonsoft.Json

VerifierSettings.AddExtraSettings(fun settings ->
  settings.NullValueHandling <- NullValueHandling.Include)

[<Fact>]
let MyTest () =
  async {
    do! Verifier.Verify(15)
          .ToTask() |> Async.AwaitTask
  }

[<Fact>]
let WithFluentSetting () =
  async {
    do! Verifier.Verify(15)
          .UseMethodName("customName")
          .ToTask() |> Async.AwaitTask
  }
do ()