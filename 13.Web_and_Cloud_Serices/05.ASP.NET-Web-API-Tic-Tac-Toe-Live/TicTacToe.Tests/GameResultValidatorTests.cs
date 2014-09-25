using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.GameLogic;

namespace TicTacToe.Tests
{
    [TestClass]
    public class GameResultValidatorTests
    {
        private readonly GameResultValidator validator = new GameResultValidator();
        [TestMethod]
        public void BlankBoardShouldReturnNotFinishedGame()
        {
            string board = "---------";
            var validatorResult = validator.GetResult(board);
            Assert.AreEqual(GameResult.NotFinished, validatorResult);
        }

        [TestMethod]
        public void DrawBoardShoulReturnDrawResult()
        {
            string board =
                  "OOX"
                + "XXO"
                + "OXO";
            var validatorResult = validator.GetResult(board);
            Assert.AreEqual(GameResult.Draw, validatorResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidBoardShoulThrowException()
        {
            string board =
                  "OOX"
                + "XaO"
                + "OXO";
            var validatorResult = validator.GetResult(board);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidBoardLengthShoulThrowException()
        {
            string board =
                  "OOX"
                + "X-O"
                + "OXOa";
            var validatorResult = validator.GetResult(board);
        }

        [TestMethod]
        public void WinnerXShoulReturnWonByX()
        {
            string board =
                  "OOX"
                + "XXO"
                + "X-O";
            var validatorResult = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByX, validatorResult);
        }

        [TestMethod]
        public void WinnerOShoulReturnWonByO()
        {
            string board =
                  "OOO"
                + "XXO"
                + "XXO";
            var validatorResult = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByO, validatorResult);
        }
    }
}
