#[cfg(test)]
mod tests {
    use std::path::Path;

    use crate::days::day4;


    #[test]
    fn should_compute_part_1() {
        let path = Path::new("./src/days/day4/input_small.txt");
        let result = day4::resolve_part_1(path);
        assert_eq!(result, 2);
    }

    #[test]
    fn should_compute_part_2() {
        let path = Path::new("./src/days/day3/input_small.txt");
        let result = day4::resolve_part_2(path);
        assert_eq!(result, 70);
    }
}