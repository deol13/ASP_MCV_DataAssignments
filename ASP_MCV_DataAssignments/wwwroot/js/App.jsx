const TableHeader = () => {
    return (
        <thead>
            <tr>
                <th>Name</th>
            </tr>
        </thead>
    )
}

class TableBody extends React.Component {
    render() {
        const personNodes = this.props.data.map(person => (
            <PersonDetails name={person.name} key={person.id} phone={person.phone} city={person.city} country={person.country}></PersonDetails>
            ));
        return <tbody>{personNodes}</tbody>;

    }
}

class ShowDetails extends React.Component {
    render() {
        return (
            <table>
                <thead>
                    <tr>
                        <th>Phone</th>
                        <th>City</th>
                        <th>Country</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td className="personPhone">{this.props.phone}</td>
                        <td className="personCity">{this.props.city}</td>
                        <td className="personCountry">{this.props.country}</td>
                    </tr>
                </tbody>
            </table>
        );
    }
}

class PersonDetails extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            showComponent: false
        };
        this._onButtonClick = this._onButtonClick.bind(this);
    }

    _onButtonClick() {
        this.setState(prevState => ({
            showComponent: !prevState.showComponent
        }));
    }


    render() {
        return ( 
            <tr>
                <td className="personName">{this.props.name}</td>
                <button onClick={this._onButtonClick}>
                    {
                        this.state.showComponent ? <ShowDetails phone={this.props.phone} city={this.props.city} country={person.country} /> : 'Show details'
                    }
                </button>
            </tr>
        );
    }
}


class PersonForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { name: '', phone: '', city: '' }
        //this.handleNameChange = this.handleNameChange.bind(this);
        //this.handlePhoneChange = this.handlePhoneChange.bind(this);
        //this.handleCityChange = this.handleCityChange.bind(this);
        //this.handelSubmit = this.handelSubmit.bind(this);
    }
    //handleNameChange(e) {
    //    this.setState({ name: e.target.value });
    //}
    //handlePhoneChange(e) {
    //    this.setState({ phone: e.target.value });
    //}
    //handleCityChange(e) {
    //    this.setState({ City: e.target.value });
    //}
    //handleSubmit(e) {
    //    e.preventDefault();
    //    const name = this.state.name.trim();
    //    const phone = this.state.phone.trim();
    //    const city = this.state.city.trim();
    //    if (!name || !phone || !city) {
    //        return;
    //    }
    //    this.props.onPersonSubmit({ name: name, phone: phone, city: city });
    //    this.setState({ name: '', phone: '', city: '' });
    //}

    render() {
        return (
            <form className="personForm" onSubmit={this.handleSubmit}>
                <input type="text" placeholder="Name" value={this.state.name} />
                <input type="text" placeholder="Phone" value={this.state.phone} />
                <input type="text" placeholder="City" value={this.state.city} />
                
                <input type="submit" value="Post" />
            </form>
        );
    }
}

/*
 <input type="text" placeholder="Name" value={this.state.name} onChange={this.handleNameChange} />
 <input type="text" placeholder="Phone" value={this.state.phone} onChange={this.handlePhoneChange} />
 <input type="text" placeholder="City" value={this.state.city} onChange={this.handleCityChange} />
 */

//<select>
//    {Option.map(() => (
//        <option value={this.state.city} onChange={this.handleCityChange}>{ }</option>
//    ))}
//</select>

class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            showComponent: false
        };
        this.handlePersonSubmit = this.handlePersonSubmit.bind(this);
    }

    loadCommentsFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }

    handlePersonSubmit(person) {
        const data = new FormData();
        data.append('Name', person.name);
        data.append('Phone', person.phone);
        data.append('City', person.city);

        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = () => this.loadCommentsFromServer();
        xhr.send(data);
    }

    componentDidMount() {
        this.loadCommentsFromServer();
        window.setInterval(
            () => this.loadCommentsFromServer(),
            this.props.pollInterval,
        );
    }

    render() {
        return (
            <div className="container">
                <h1>People</h1>
                <table className="table">
                    <TableHeader />
                    <TableBody data={this.state.data} />
                </table>
                <PersonForm />
            </div>
        );
    }
}
//<PersonForm onPersonSubmit={this.handlePersonSubmit} />

//ReactDOM.render(<App url="/people" submitUrl="/people/new" pollInterval={2000}/>, document.getElementById('root'));
ReactDOM.render(<App url="/people" pollInterval={2000}/>, document.getElementById('root'));