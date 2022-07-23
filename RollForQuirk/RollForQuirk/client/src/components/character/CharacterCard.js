import React from "react"
import { useNavigate } from "react-router-dom"
import { Card, CardBody, CardText, CardTitle, CardSubtitle, Button } from "reactstrap"

export const CharacterCard = ({character}) =>{
    
    const navigate = useNavigate()
    return (
        <Card onClick={() => navigate(`${character.id}/details`, {state: character})}>
        <CardTitle>{character?.characterName}</CardTitle>
        <CardBody>
            <CardSubtitle>Race: {character?.characterRace?.characterRace}</CardSubtitle>
            <CardSubtitle>Class: {character?.characterProfession?.characterProfession}</CardSubtitle>
            <CardSubtitle>Alignment: {character?.characterAlignment?.characterAlignment} </CardSubtitle>
            {/* <CardSubtitle>Traits: {character?.traits?.map(res => <CardText>{res.characterTrait}</CardText>)}</CardSubtitle> */}
        </CardBody>
    </Card>
    )
}