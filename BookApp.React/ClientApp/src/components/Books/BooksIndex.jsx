import React, { Component } from 'react'


export class BooksIndex extends Component {
    constructor(props) {
        super(props);

        this.state = {
            books: [],
            loading: true
        };

        this.renderBooksTable = this.renderBooksTable.bind(this);
    }

    // OnInitialized()
    componentDidMount() {
        this.populateBooksData()
    }


    renderBooksTable(books) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Description</th>
                        <th>Created</th>
                        <th>-</th>
                    </tr>
                </thead>
                <tbody>
                    {books.map(book =>
                        <tr key={book.id}>
                            <td>{book.id}</td>
                            <td>{book.description}</td>
                            <td>{book.created}</td>
                            <td></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading....</em></p>
            : this.renderBooksTable(this.state.books);

        return (
            <div>
                <h1>Books</h1>
                <h2>제가 집필한 책입니다.</h2>
                {contents}
            </div>
        );
    }

    async populateBooksData() {
        const response = await fetch('/api/Books');
        const data = await response.json();
        this.setState({ books: data, loading: false });

    }
}