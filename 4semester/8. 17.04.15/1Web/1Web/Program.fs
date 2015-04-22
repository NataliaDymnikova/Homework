open System.IO 
open System.Net
open System.Threading.Tasks

/// Print count symbols in all links on page.
let mainFunction (url) =
    /// Write url and number of symbols there.
    let fetchAsync(url: string) =    
        async { 
            let req = WebRequest.Create(url)
            let! resp = req.AsyncGetResponse()            
            let stream = resp.GetResponseStream()            
            let reader = new StreamReader(stream) 
            let html1 = reader.ReadToEndAsync()           
            let! html = Async.AwaitTask(html1)
            do printfn "%s --- %d" url html.Length
        }
    /// Return string from url.
    let http(url: string) =
        let req = System.Net.WebRequest.Create(url)
        let resp = req.GetResponse()
        let stream = resp.GetResponseStream()
        let reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        resp.Close()
        html

    let expression = new System.Text.RegularExpressions.Regex("<a.*href=\"http.*\">")
    let allUrls = expression.Matches(http(url))
    let tasks = [for urlTemp in allUrls -> 
                                    let value = urlTemp.Value
                                    fetchAsync(value.Substring(value.IndexOf("\"") + 1
                                        , value.IndexOf("\">") - value.IndexOf("\"") - 1))]    
    Async.Parallel tasks |> Async.RunSynchronously |> ignore

mainFunction("http://se.math.spbu.ru/SE/Members/ylitvinov/13-44/resultsSpring2015_244_Yurii")