#[cfg(test)]
mod tests {
    use std::path::Path;

    use crate::days::day3::{resolve_part_1};


    #[test]
    fn should_compute_part_1() {
        let result = resolve_part_1(Path::new("src/days/day3/input_small.txt"));
        assert_eq!(result, 157);
    }

    // #[test]
    // fn should_compute_part_2() {
    //     let result = resolve_part_2("src/days/day2/input_small.txt");
    //     assert_eq!(result, 12);
    // }
}