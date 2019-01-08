// Learn more about F# at http://fsharp.org

open System
open System.Net
open System
open System.IO
open System.Web

let extractWebPageText (reader:IO.StreamReader) = 
    reader.ReadToEnd()

// Fetch the contents of a web page
let fetchUrlReader callback url =        
    try
        let req = WebRequest.Create(Uri(url)) 
        use resp = req.GetResponse() 
        use stream = resp.GetResponseStream()
        use reader = new IO.StreamReader(stream)
        callback reader
    with
        | :? System.Net.WebException -> "#ERROR#"

let fetchUrlText url = 
    fetchUrlReader extractWebPageText url

type personType = { forename : string ; surname : string ; dob : DateTime }

[<EntryPoint>]
let main argv =

    Log.WriteMsg "Starting"

    let formatStringFromPerson person : string = "Name: " + person.forename + " " + person.surname + ", Date of birth: " + person.dob.ToLongDateString()
    let logPerson person =  formatStringFromPerson person |> Log.WriteMsg
    let logPeople people = List.iter (fun x -> logPerson x) people

    let me = { 
        personType.forename = "Mathew";
        personType.surname = "Coburn";
        personType.dob = System.DateTime.Parse "14-05-1971"
    }

    let people = [ me ; me ]

    people |> logPeople

    let url = "https://www.ukclimbing.com/"
    Log.WriteMsg url
    fetchUrlText url |> Log.WriteMsg
    
    Log.WriteMsg "Stopping"

    0 // return an integer exit code
