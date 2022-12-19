#[cfg(test)]
mod tests {
    use std::{path::Path, fs::read_to_string};

    use crate::days::day5;

    #[test]
    fn should_compute_part_1() {
        let path = Path::new("./src/days/day5/input_small.txt");
        let string = read_to_string(path).unwrap();
        let result = day5::resolve_part_1(&string);
        assert_eq!(result, "CMZ");
    }

    #[test]
    fn should_compute_part_2() {
        let path = Path::new("./src/days/day5/input_small.txt");
        let string = read_to_string(path).unwrap();
        let result = day5::resolve_part_2(&string);
        assert_eq!(result, "MCD");
    }
}