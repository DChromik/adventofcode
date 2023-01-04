use std::collections::HashSet;

pub fn resolve_part_1(string: &str) -> String {
    let rope = Rope::new();
    let mut visited_coords = HashSet::new();
    visited_coords.insert("0:0");
    for line in string.lines() {
        let instructions = line.split(" ");
    }
    return visited_coords.len().to_string();
}

pub fn resolve_part_2(string: &str) -> String {
    return "Not implemented yet".to_string();
}

struct Vector2 {
    x: i32,
    y: i32,
}

impl Vector2 {
    pub fn new() -> Vector2 {
        Vector2 { x: 0, y: 0 }
    }
    
    pub fn key(&self) -> String {
        format!("{}:{}", self.x, self.y)
    }
}

struct Rope {
    head: Vector2,
    tail: Vector2,
}

impl Rope {
    pub fn new() -> Rope {
        Rope {
            head: Vector2::new(),
            tail: Vector2::new()
        }
    }
    
    pub fn move_head(&mut self, direction: &str) {
        match direction {
            "R" => self.head.x += 1,
            "L" => self.head.x -= 1,
            "U" => self.head.y += 1,
            "D" => self.head.x -= 1,
            _ => {}
        }
    }
    
    fn move_tail(&mut self) {

    }
}