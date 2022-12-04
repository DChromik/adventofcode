use std::fs::read_to_string;

#[derive(Clone, Copy, PartialEq, Eq)]
enum Shape {
    Rock = 1,
    Paper = 2,
    Scissors = 3,
}

pub fn resolve_part_1(path: &str) -> u64 {
    let file = read_to_string(path).unwrap();
    let result = file.lines()
        .map(|line| line.as_bytes())
        .map(|line| line_to_shapes(line))
        .map(|line| get_line_score(&line))
        .sum::<u64>();
    return result;
}

pub fn resolve_part_2(path: &str) -> u64 {
    let file = read_to_string(path).unwrap();
    let result = file.lines()
        .map(|line| line.as_bytes())
        .map(|line| line_to_shapes_2(line))
        .map(|line| get_line_score(&line))
        .sum::<u64>();
    return result;
}

fn line_to_shapes(line: &[u8]) -> [Shape; 2] {
    [oponnent_to_shape(line[0]), player_to_shape(line[2])]
}

fn line_to_shapes_2(line: &[u8]) -> [Shape; 2] {
    let oponnent = oponnent_to_shape(line[0]);
    return [
        oponnent,
        required_result_to_shape(oponnent, line[2]),
    ];
}

fn get_line_score(shapes: &[Shape; 2]) -> u64 {
    let player_score = shapes[1] as u64;
    let result_score = get_result_score(shapes[0], shapes[1]);
    return player_score + result_score;
}

fn get_result_score(oponnent: Shape, player: Shape) -> u64 {
    if is_draw(oponnent, player) {
        return 3;
    }
    if is_loss(oponnent, player) {
        return 0;
    }
    return 6;
}

fn is_draw(oponnent: Shape, player: Shape) -> bool {
    return player == oponnent;
}

fn is_loss(oponnent: Shape, player: Shape) -> bool {
    return get_losing_shape(oponnent) == player;
}

fn player_to_shape(shape: u8) -> Shape {
    match shape {
        b'X' => Shape::Rock,
        b'Y' => Shape::Paper,
        b'Z' => Shape::Scissors,
        _ => Shape::Rock,
    }
}

fn oponnent_to_shape(shape: u8) -> Shape {
    match shape {
        b'A' => Shape::Rock,
        b'B' => Shape::Paper,
        b'C' => Shape::Scissors,
        _ => Shape::Rock,
    }
}

fn required_result_to_shape(oponnent: Shape, result: u8) -> Shape {
    if result == b'Y' { // Should draw
        return oponnent;
    }
    if result == b'X' { // Should lose
        return get_losing_shape(oponnent)
    }
    return get_winning_shape(oponnent);
}

fn get_winning_shape(shape: Shape) -> Shape {
    match shape {
        Shape::Paper => Shape::Scissors,
        Shape::Rock => Shape::Paper,
        Shape::Scissors => Shape::Rock,
    }
}

fn get_losing_shape(shape: Shape) -> Shape {
    match shape {
        Shape::Paper => Shape::Rock,
        Shape::Rock => Shape::Scissors,
        Shape::Scissors => Shape::Paper,
    }
}