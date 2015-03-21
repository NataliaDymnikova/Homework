module Computers
/// OS
type OSEnum =
    | Windows
    | Linux
let OS = [(OSEnum.Windows, 50); (OSEnum.Linux, 75)]

/// Type of Computers - can try to infect, has member isInfect.
type Computer (os : OSEnum, isInfect : bool) =
    let random = System.Random()
    let protection = 
        let rec recProtection list = 
            match list with
            | h::t -> 
                let name, number = h
                if name = os then
                    number
                else
                    recProtection t
            | _ -> 100
        recProtection OS

    let mutable isInfectMy =  isInfect
    member c.Protection = 
        let rec recProtection list = 
            match list with
            | h::t -> 
                let name, number = h
                if name = os then
                    number
                else
                    recProtection t
            | _ -> 100
        recProtection OS

    member c.IsInfect = isInfectMy

    member c.TryToInfect = 
        if not isInfect then
            let r = random.Next(1, 100)
            if r < c.Protection then
                isInfectMy <- true

/// Initialization computers
let computers = [new Computer(OSEnum.Windows, false); new Computer(OSEnum.Linux, true);new Computer(OSEnum.Linux, false); new Computer(OSEnum.Windows, false)]
