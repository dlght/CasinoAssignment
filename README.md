# Casino Assignment System Documentation

## Introduction
CasinoAssignment is a command-line application designed to facilitate interactions with a user's wallet within the context of gaming. 
It allows users to perform various actions such as depositing money, withdrawing money, and placing bets, all of which affect the balance of their wallet.

## Features
### User Wallet Management
Users can perform operations like depositing and withdrawing money from their wallet.
The system ensures the validity of amounts entered for depositing and withdrawing, providing appropriate error messages if necessary.
### Betting Functionality
Users can place bets from their wallet balance.
The system checks for sufficient funds before accepting a bet and provides feedback accordingly.
Winnings, if any, are automatically deposited back into the user's wallet.

## Usage
### Main Menu
Upon starting the application, users are prompted to input actions via the command line.
Available actions include depositing money, withdrawing money, placing bets, and exiting the application.
### Deposit
To deposit money into the wallet, users should input the desired deposit amount.
If the deposit is successful, the system confirms the transaction and displays the updated wallet balance.
### Withdraw
Users can withdraw money from their wallet by specifying the withdrawal amount.
If the withdrawal is successful, the system confirms the transaction and displays the updated wallet balance.
If the withdrawal amount exceeds the available balance, the system notifies the user of insufficient funds.
### Betting
Users can place bets using the funds available in their wallet.
The system verifies if the bet amount is valid and if the user has sufficient funds to place the bet.
After placing a bet, the system determines if the user has won or lost and updates the wallet balance accordingly.
### Exiting the Application
Users can exit the application at any time by inputting the exit command.
Upon exiting, the system displays a farewell message.

## Dependencies
This application relies on the Game.Engine, Game.Portfolio, and Game.UI namespaces for handling game-related functionalities, wallet management, and user interface interactions, respectively.
