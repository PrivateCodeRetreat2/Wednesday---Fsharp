[<VerifyXunit.UsesVerify>]
module Tests

open Xunit
open VerifyTests
open VerifyXunit
open Newtonsoft.Json


VerifierSettings.AddExtraSettings(fun settings ->
  settings.NullValueHandling <- NullValueHandling.Include)

let isAliveNextStep (alive:bool , numberOfNeighbors:int) = 
  (alive && numberOfNeighbors = 2) || numberOfNeighbors = 3

[<Fact>]
let RuleForCellAndNeighbors () =
  async {
      let next = seq { for alive in [|false; true|] -> seq { for n in 1 .. 8 -> $"{alive},{n}  => {isAliveNextStep(alive , n)}"}}
      do! Verifier.Verify(next)
              .ToTask() |> Async.AwaitTask
  }
