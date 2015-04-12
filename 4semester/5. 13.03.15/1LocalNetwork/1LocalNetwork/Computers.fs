module Computers
/// OS
type OSEnum =
    | Windows
    | Linux
let OS = new Collections.Map<OSEnum,int> ([(OSEnum.Windows, 50); (OSEnum.Linux, 75)])

/// Type of Computers - can try to infect, has member isInfect.
type Computer (os : OSEnum, isInfect : bool) =
    let random = System.Random()
    let mutable isInfectMy =  isInfect
    
    member c.Protection = OS.Item os
    member c.IsInfect = isInfectMy
    member c.TryToInfect = 
        if not isInfect then
            let r = random.Next(1, 100)
            if r <= c.Protection then
                isInfectMy <- true
    member c.Copy() = new Computer(os, isInfect)

/// Initialization computers
let computers = [new Computer(OSEnum.Windows, false); new Computer(OSEnum.Linux, true);
    new Computer(OSEnum.Linux, false); new Computer(OSEnum.Windows, false)]
