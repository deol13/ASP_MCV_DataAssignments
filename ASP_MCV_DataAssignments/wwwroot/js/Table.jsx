const TableHeader = () => {
    return (
        <thead>
            <tr>
                <th>Name</th>
                <th>Phone</th>
                <th>City</th>
            </tr>
        </thead>
    )
}

const TableBody = () => {
    const rows = props.peopleData.map((row, index) => {
        return (
            <tr key={index}>
                <td>{ row.Name }</td>
                <td>{ row.Phone }</td>
                <td>{ row.City.Name }</td>
            </tr>
        )
    })

    return <tbody>{rows}</tbody>
}

class Table extends Component {
    render() {
        //const { peopleData } = this.props

        return (
            <table>
                <TableHeader />
                <TableBody peopleData={peopleData} />
            </table>
        )
    }
}