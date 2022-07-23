import React, {useState} from "react"
import { useNavigate } from "react-router-dom"
import { Card, CardBody, CardText, CardTitle, CardSubtitle, Button } from "reactstrap"
import { CharacterDetails } from "./CharacterDetails"

export const CharacterCard = ({character}) =>{
    
    const [isOpen, updateIsOpen] = useState(false)
    const navigate = useNavigate()
    return (
        <>
            
            <Card className="container-sm col-md-4" onClick={()=> updateIsOpen(!isOpen)} style={{cursor: 'pointer'}}>
                <CardTitle>{character?.characterName}</CardTitle>
                <CardBody>
                    <CardSubtitle>Race: {character?.characterRace?.characterRace}</CardSubtitle>
                    <CardSubtitle>Class: {character?.characterProfession?.characterProfession}</CardSubtitle>
                    <CardSubtitle>Alignment: {character?.characterAlignment?.characterAlignment} </CardSubtitle>
                    {/* <CardSubtitle>Traits: {character?.traits?.map(res => <CardText>{res.characterTrait}</CardText>)}</CardSubtitle> */}
                </CardBody>
            </Card>
            <CharacterDetails character={character} isOpen={isOpen} updateIsOpen={updateIsOpen}/>
        </>

    )
}