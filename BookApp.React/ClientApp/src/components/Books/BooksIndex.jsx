import React, { Component } from 'react'


export class BooksIndex extends Component {
    constructor(props) {
        super(props);

        this.state = {
            books: [],
            loading: true
        };

    }

    render() {
        return (
            <div>
                <h1>Books</h1>
                <h2>제가 집필한 책입니다.</h2>
                
            </div>
        );
    }
}