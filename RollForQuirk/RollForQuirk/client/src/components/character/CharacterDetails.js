import { useLocation, useParams, useNavigate, Link } from "react-router-dom"
import { useEffect, useState } from "react"
import { Card, CardBody, CardText, CardTitle, CardSubtitle, Button } from "reactstrap"

export const CharacterDetails = () =>{

    const location = useLocation()
    const charId = useParams()
    const navigate = useNavigate()

    const handleDelete = () =>{

    }

    return(
        <>
        <Card onClick={()=> navigate("/")}>

        <CardTitle>{location.state.characterName}</CardTitle>
        <CardBody>
            <CardSubtitle>Race: {location.state.characterRace.characterRace}</CardSubtitle>
            <CardSubtitle>Class: {location.state.characterProfession.characterProfession}</CardSubtitle>
            <CardSubtitle>Alignment: {location.state.characterAlignment.characterAlignment} </CardSubtitle>
            <CardSubtitle>Traits: {location.state.traits?.map(res => <CardText>{res.characterTrait}</CardText>)}</CardSubtitle>
            {console.log(location)}
            
        </CardBody>
        </Card>
        <Button onClick={()=> navigate(`/${location.state.id}/edit`)}>Edit</Button><Button onClick={handleDelete}>Delete</Button>
        </>
    )
}