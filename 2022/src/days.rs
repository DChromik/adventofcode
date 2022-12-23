pub mod day1 {
    mod solution;
    mod tests;
    
    pub use solution::compute_part_1;
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

type ResolveFunction = fn (string: &str) -> String;
pub const SOLUTIONS: [(ResolveFunction, ResolveFunction); 4] = [
    (day5::resolve_part_1, day5::resolve_part_2),
    (day6::resolve_part_1, day6::resolve_part_2),
    (day7::resolve_part_1, day7::resolve_part_2),
    (day8::resolve_part_1, day8::resolve_part_2),
];
