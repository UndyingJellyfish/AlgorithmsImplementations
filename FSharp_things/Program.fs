let rec LCS list1 list2 =
    match (list1,list2) with
        head1::tail1, head2::tail2 ->
            if head1 = head2 then
                printf "head :: LCS tail1 tail2"
                head1 :: LCS tail1 tail2
            else
                let c1 = LCS list1 tail2 in
                let c2 = LCS tail1 list2 in
                if c1.Length > c2.Length then
                    printf "c1"
                    c1
                else
                    printf "c2"
                    c2  
 
        | _ -> []
let stringToList (s:string) =
    [for c in s -> c]
 
[<EntryPoint>]
let main argv =
    let l1 = stringToList (System.Console.In.ReadLine())
    printf "read first input %s\n" (List.toArray l1 |> System.String)
 
    let l2 = stringToList (System.Console.In.ReadLine())
    printf "read second input %s\n" (List.toArray l2 |> System.String)
 
    LCS l1 l2 |> List.toArray |> System.String |> printfn "%A"
    printf "now we're done"
    System.Console.ReadLine() |> ignore
    0