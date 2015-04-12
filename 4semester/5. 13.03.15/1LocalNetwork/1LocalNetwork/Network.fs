module Network
open Computers

let size = 3
/// Initialization network
let network = [|for x in 0..size -> [|for y in 0..size -> false|]|]
network.[0].[1] <- true
network.[1].[0] <- true
network.[2].[1] <- true
network.[1].[2] <- true
network.[3].[2] <- true
network.[2].[3] <- true

/// Check is all infect.
let isAllInfect (computers : List<Computer>) =
    List.forall (fun (x: Computer) -> x.IsInfect) computers


