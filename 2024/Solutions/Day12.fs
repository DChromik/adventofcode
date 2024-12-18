module Day12

type Position = int * int

type Plot = char

type Region =
    { area: int
      perimeter: int}

type Grid = Map<Position, Plot>

type CollectRegionsState =
    { checkedPositions: Set<Position>
      regions: List<Region> }

    static member Default = { checkedPositions = Set []; regions = [] }
    static member getRegions(state: CollectRegionsState) = state.regions

module Grid =
    let fromInput (lines: seq<string>) : Grid =
        lines
        |> Seq.map (fun line -> line.Trim().ToCharArray())
        |> Seq.indexed
        |> Seq.fold
            (fun grid (y, row) ->
                row
                |> Seq.indexed
                |> Seq.fold (fun g (x, plot) -> g |> Map.add (x, y) plot) grid)
            (Grid [])

    let findNeighbours (grid: Grid) (x, y) =
        [ (x + 1, y); (x - 1, y); (x, y + 1); (x, y - 1) ]
        |> List.choose (fun position -> Map.tryFind position grid |> Option.map (fun p -> (p, position)))

    let private checkRegion grid (position: Position) (plot: Plot) =
        let perimeters =
            Seq.unfold (fun (checkedPositions: Set<Position>, positions: List<Position>) ->
                match positions with
                | head :: tail ->
                    let updatedChecked = Set.add head checkedPositions
                    let neighbours = findNeighbours grid head |> List.filter (fun (pl, pos) -> pl = plot && (Set.contains pos updatedChecked |> not)) |> List.map snd
                    Some(4 - neighbours.Length, (Set.add head checkedPositions, List.append tail neighbours))
                | _ -> None
            ) (Set<Position>[], [position])

        { area = (Seq.length perimeters); perimeter = (Seq.sum perimeters)}

    let private checkPlot grid (state: CollectRegionsState) position plot =
        if Set.contains plot state.checkedPlots then
            state
        else
            Seq.

    let collectRegions (grid: Grid) : list<Region> =
        grid
        |> Map.fold (checkPlot grid) CollectRegionsState.Default
        |> CollectRegionsState.getRegions

let resolvePart1 (lines: seq<string>) : int =
    let grid = Grid.fromInput lines

    printfn "%A" (Grid.findNeighbours grid (0, 0))

    0

let resolvePart2 (lines: seq<string>) : int = 0
