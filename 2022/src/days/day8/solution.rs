pub fn resolve_part_1(string: &str) -> String {
    let forest = Forest::new(string);
    return forest.count_visible().to_string();
}

pub fn resolve_part_2(string: &str) -> String {
    let forest = Forest::new(string);
    return forest.get_highest_scenic_score().to_string();
}

struct Forest {
    columns: usize,
    rows: usize,
    trees: Vec<u8>,
}

impl Forest {
    pub fn new(string: &str) -> Forest {
        let mut trees = Vec::new();
        let mut columns = 0;
        let mut rows = 0;
        for line in string.lines() {
            let line_trees = line.as_bytes();
            if columns == 0 {
                columns = line_trees.len();
            }
            rows += 1;
            trees.extend_from_slice(line_trees);
        }
        return Forest { columns, rows, trees };
    }
    
    pub fn count_visible(&self) -> usize {
        let mut count = 0;
        for y in 0..self.rows {
            for x in 0..self.columns {
                if self.is_visible(x, y) {
                    count += 1;
                }
            }
        }
        return count;
    }
    
    pub fn get_highest_scenic_score(&self) -> usize {
        let mut highest_score = 0;
        for y in 0..self.rows {
            for x in 0..self.columns {
                let score = self.get_scenic_score(x, y);
                if score > highest_score {
                    highest_score = score;
                }
            }
        }
        return highest_score;
    }
    
    pub fn is_visible(&self, x: usize, y: usize) -> bool {
        return self.is_on_edge(x, y)
            || self.is_visible_left(x, y).0 || self.is_visible_right(x, y).0
            || self.is_visible_up(x, y).0 || self.is_visible_down(x, y).0;
    }
    
    pub fn get_scenic_score(&self, x: usize, y: usize) -> usize {
        if self.is_on_edge(x, y) {
            return 0;
        }
        return self.is_visible_left(x, y).1 * self.is_visible_right(x, y).1
            * self.is_visible_up(x, y).1 * self.is_visible_down(x, y).1;
    }
    
    pub fn is_visible_left(&self, x: usize, y: usize) -> (bool, usize) {
        let index = self.get_index(x, y);
        let tree_size = self.trees[index];
        let mut scenic_score = 0;
        for col in (0..x).rev() {
            scenic_score += 1;
            let index = self.get_index(col, y);
            if self.trees[index] >= tree_size {
                return (false, scenic_score);
            }
        }
        return (true, scenic_score);
    }
    
    pub fn is_visible_right(&self, x: usize, y: usize) -> (bool, usize) {
        let index = self.get_index(x, y);
        let tree_size = self.trees[index];
        let mut scenic_score = 0;
        for col in x + 1..self.columns {
            scenic_score += 1;
            let index = self.get_index(col, y);
            if self.trees[index] >= tree_size {
                return (false, scenic_score);
            }
        }
        return (true, scenic_score);
    }
    
    pub fn is_visible_up(&self, x: usize, y: usize) -> (bool, usize) {
        let index = self.get_index(x, y);
        let tree_size = self.trees[index];
        let mut scenic_score = 0;
        for row in (0..y).rev() {
            scenic_score += 1;
            let index = self.get_index(x, row);
            if self.trees[index] >= tree_size {
                return (false, scenic_score);
            }
        }
        return (true, scenic_score);
    }
    
    pub fn is_visible_down(&self, x: usize, y: usize) -> (bool, usize) {
        let index = self.get_index(x, y);
        let tree_size = self.trees[index];
        let mut scenic_score = 0;
        for row in y + 1..self.rows {
            scenic_score += 1;
            let index = self.get_index(x, row);
            if self.trees[index] >= tree_size {
                return (false, scenic_score);
            }
        }
        return (true, scenic_score);
    }
    
    fn is_on_edge(&self, x: usize, y: usize) -> bool {
        return x == 0 || x == self.columns - 1 || y == 0 || y == self.rows - 1;
    }

    pub fn get_index(&self, x: usize, y: usize) -> usize {
        return y * self.columns + x;
    }
}