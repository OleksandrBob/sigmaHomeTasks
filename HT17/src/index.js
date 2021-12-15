import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';


  function Square(props){
    return(
      <button
        className="square"
        onClick={props.onClick}
      >
        {props.value}
      </button>
    );
  }
  class Board extends React.Component {  
    renderSquare(i) {
      return (
        <Square
          value={this.props.squares[i]}
          onClick={() => this.props.onClick(i)}
        />
      );
    }
  

    renderRow(r){
        const squares = [];
        let sqIndex = r;
        for(let i = 0; i < 3; i++){
            squares.push(this.renderSquare(sqIndex));
            sqIndex++;
        }

        return(
            <div className="board-row">
            {squares}
            </div>
        );
    }

    renderBoard(){
        const rows = [];

        for(let i = 0; i <= 6; i += 3){
            rows.push(this.renderRow(i));
        }

        return rows;
    }

    render() {
        return (
            <div className='rows-container'>
                {this.renderBoard()}
            </div>
        );
    }
  }

  class Game extends React.Component {
    constructor(props){
        super(props);
        this.state = {
            history: [{squares: Array(9).fill(null)}],
            xIsNext: true,
            stepNumber: 0
        };

        this.SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition;
        this.Recognition = new this.SpeechRecognition();

        this.Recognition.onresult = (event) => {
          console.log(event.results[0][0].transcript)
          const transcription = event.results[0][0].transcript;

          if(isNaN(transcription)){
            this.correctSpeechResult = false;
            alert("is not a number");
          }
          else if (parseInt(transcription) > 9 || parseInt(transcription) < 1){
            this.correctSpeechResult = false;
            alert("bad range");
          }
          else{
            this.correctSpeechResult = true;
            this.handleClick(parseInt(transcription) - 1);
          }
        };
    }

    handleClick(i) {
        const history = this.state.history.slice(0, this.state.stepNumber + 1);
        const current = history[history.length - 1];
        const squares = current.squares.slice();
        if (calculateWinner(squares) || squares[i]) {
          return;
        }
        
        squares[i] = this.state.xIsNext ? 'X' : 'O';
        this.setState({
          history: history.concat([{
            squares: squares,
          }]),
          xIsNext: !this.state.xIsNext,
          stepNumber: history.length,
        });
      }

    jumpTo(step) {
      this.setState({
        stepNumber: step,
        xIsNext: (step % 2) === 0,
      });
    }

      handleSpeech(){        
        this.Recognition.start();
      }

    render() {
        const history = this.state.history;
        const current = history[this.state.stepNumber];
        const squares = current.squares.slice();
        const winner = calculateWinner(current.squares);

        let isAllinitialised = true;
        for(let i=0; i<9;i++){
            if(squares[i] == null){
                isAllinitialised = false;
                break;
            }
        }

        const moves = history.map((step, move) => {
            const desc = move ?
                'Go to move #' + move :
                'Go to game start';
            return (
                <li key = {move}>
                    <button onClick={() => this.jumpTo(move)}>{desc}</button>
                </li>
            );
        });

        let status;
        if (winner) {
          status = 'Winner: ' + winner;
        }
        else if(winner === null && isAllinitialised === true){
            status = 'No one wins';
            alert('No one wins');
        }
        else {
          status = 'Next player: ' + (this.state.xIsNext ? 'X' : 'O');
        }

      return (
        <div className="game">
          <div className="game-board">
          <Board
            squares={current.squares}
            onClick={(i) => this.handleClick(i)}
          />
          </div>
          <div className="game-info">
          <div>{status}</div>
            <ol>{moves}</ol>
          </div>
          <div id= "voice-control">
            <button onClick={()=> this.handleSpeech()}>Next step</button>
          </div>
        </div>
      );
    }
  }
  
  // ========================================
  
  ReactDOM.render(
    <Game />,
    document.getElementById('root')
  );
  
  
  function calculateWinner(squares) {
    const lines = [
      [0, 1, 2],
      [3, 4, 5],
      [6, 7, 8],
      [0, 3, 6],
      [1, 4, 7],
      [2, 5, 8],
      [0, 4, 8],
      [2, 4, 6],
    ];
    for (let i = 0; i < lines.length; i++) {
      const [a, b, c] = lines[i];
      if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
        return squares[a];
      }
    }
    return null;
  }