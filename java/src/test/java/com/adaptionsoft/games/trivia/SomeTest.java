package com.adaptionsoft.games.trivia;

import static org.junit.Assert.*;

import com.adaptionsoft.games.trivia.runner.GameRunner;
import org.approvaltests.Approvals;
import org.junit.Test;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;
import java.util.Random;

public class SomeTest {

	@Test
	public void golden_master() throws Exception {
		ByteArrayOutputStream stream = new ByteArrayOutputStream();
		System.setOut(new PrintStream(stream));

		GameRunner runner = new GameRunner();
		Random rng = new Random(123);

		for(int i = 0; i < 100; i++){
			System.out.println("Playing game "+i);
			runner.PlayGame(rng);
		}

		Approvals.verify(stream.toString());
	}
}
