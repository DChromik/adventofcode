use std::collections::HashSet;

pub fn resolve_part_1(string: &str) -> String {
    const WINDOW_SIZE: usize = 4;
    let result = string.as_bytes()
        .windows(WINDOW_SIZE)
        .position(are_all_different)
        .unwrap() + WINDOW_SIZE; 
    return result.to_string();
}

pub fn resolve_part_2(string: &str) -> String {
    const WINDOW_SIZE: usize = 14;
    let result = string.as_bytes()
        .windows(WINDOW_SIZE)
        .position(are_all_different)
        .unwrap() + WINDOW_SIZE; 
    return result.to_string();
}

fn are_all_different(window: &[u8]) -> bool {
    let mut seen = HashSet::new();
    for character in window {
        if seen.contains(character) {
            return false;
        }
        seen.insert(character);
    }
    return true;
}