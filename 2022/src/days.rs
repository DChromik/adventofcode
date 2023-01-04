pub mod day1 {
    mod solution;
    mod tests;
    
    pub use solution::resolve_part_1;
    pub use solution::resolve_part_2;
}

pub mod day2 {
    mod solution;
    mod tests;
    
    pub use solution::resolve_part_1;
    pub use solution::resolve_part_2;
}

pub mod day3 {
    mod solution;
    mod tests;

    pub use solution::resolve_part_1;
    pub use solution::resolve_part_2;
}

pub mod day4 {
    mod solution;
    mod tests;
    
    pub use solution::resolve_part_1;
    pub use solution::resolve_part_2;
}

pub mod day5 {
    mod solution;
    mod tests;
    
    pub use solution::resolve_part_1;
    pub use solution::resolve_part_2;
}

pub mod day6 {
    mod solution;
    mod tests;
    
    pub use solution::resolve_part_1;
    pub use solution::resolve_part_2;
}

pub mod day7 {
    mod solution;
    mod tests;
    
    pub use solution::resolve_part_1;
    pub use solution::resolve_part_2;
}

pub mod day8 {
    mod solution;
    mod tests;
    
    pub use solution::resolve_part_1;
    pub use solution::resolve_part_2;
}

pub mod day9 {
    mod solution;
    mod tests;
    
    pub use solution::resolve_part_1;
    pub use solution::resolve_part_2;
}

type ResolveFunction = fn (string: &str) -> String;
pub const SOLUTIONS: [(ResolveFunction, ResolveFunction); 9] = [
    (day1::resolve_part_1, day1::resolve_part_2),
    (day2::resolve_part_1, day2::resolve_part_2),
    (day3::resolve_part_1, day3::resolve_part_2),
    (day4::resolve_part_1, day4::resolve_part_2),
    (day5::resolve_part_1, day5::resolve_part_2),
    (day6::resolve_part_1, day6::resolve_part_2),
    (day7::resolve_part_1, day7::resolve_part_2),
    (day8::resolve_part_1, day8::resolve_part_2),
    (day9::resolve_part_1, day9::resolve_part_2),
];
