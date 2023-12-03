import { ReadStream } from "fs";
import { reduceLines } from "../util";

type CubeColor = 'red' | 'green' | 'blue';

type Cubes = {
	red: number;
	green: number;
	blue: number;
};

type Game = Cubes[];

const cubesInBag = {
	red: 12,
	green: 13,
	blue: 14
};

export function resolvePart1(stream: ReadStream): Promise<number> {
	return reduceLines(stream, (sum, line, index) => {
		const game = parseLine(line);

		return isGamePossible(game) ? sum + index + 1 : sum;
	}, 0);
}

export function resolvePart2(stream: ReadStream): Promise<number> {
	return Promise.resolve(0);
}

function parseLine(line: string): Game {
	const draws = line.split(':')[1].split(';');
	return draws.map((draw) => {
		const drawnCubes = draw.split(',');
		return drawnCubes.reduce((cubes, current) => {
			const [amount, cubeColor] = current.trim().split(' ');
			cubes[cubeColor as CubeColor] = Number.parseInt(amount, 10);
			return cubes;
		}, { red: 0, green: 0, blue: 0 } as Cubes);
	});
}

function isGamePossible(game: Game): boolean {
	return game.every((round) => {
		return round.red <= cubesInBag.red && round.blue <= cubesInBag.blue && round.green <= cubesInBag.green;
	});
}
