package walking.game;
// package player.MadlyRotatingBuccaneer;

import walking.game.player.MadlyRotatingBuccaneer;
import walking.game.player.Player;

public class WalkingBoardWithPlayers extends WalkingBoard {
    private walking.game.player.Player[] players;
    private int round;
    public static final int SCORE_EACH_STEP = 13;
    public WalkingBoardWithPlayers(int[][] board, int playerCount){
        super(board);
        if(playerCount < 2)
        {
            throw new IllegalArgumentException("Number of players is less than 2!");
        }
        initPlayers(playerCount);
    }
    public WalkingBoardWithPlayers(int size,int playerCount){
        super(size);
        if(playerCount < 2)
        {
            throw new IllegalArgumentException("Number of players is less than 2!");
        }

        initPlayers(playerCount);
    }
    private void initPlayers(int playerCount) {
        players = new Player[playerCount];
        players[0] = new MadlyRotatingBuccaneer();
        for (int i = 1; i < playerCount; i++) {
            players[i] = new Player();
        }
        round = 0;
    }
    public int[] walk( int... stepCounts) {
        int[] playerScores = new int[players.length]; 
        int currentPlayerIndex = 0;// We go through all the step counts starting form fisrt player
        int totalSteps = 0;
        for (int stepCount : stepCounts) { 
           // Player currentPlayer = players[currentPlayerIndex]; 
           players[currentPlayerIndex].turn(); // The player takes one turn
           totalSteps += stepCount; 
           totalSteps  = totalSteps < SCORE_EACH_STEP ? totalSteps : SCORE_EACH_STEP;
            int previousTileValue = moveAndSet(players[currentPlayerIndex].getDirection(), totalSteps);
            
            players[currentPlayerIndex].addToScore(previousTileValue);
                        
            currentPlayerIndex++;
            // We increase the index of the current player, if we have reached the end of the array, we return to the beginning            currentPlayerIndex++;
            if (currentPlayerIndex == players.length) {
                currentPlayerIndex = 0;
            }

        }
    // add each player's score
    for (int i = 0; i < players.length; i++) 
    {
        playerScores[i] = players[i].getScore();
    }
        return playerScores;
    }

}
