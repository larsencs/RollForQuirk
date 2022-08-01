import { Button, Modal, ModalBody, ModalHeader, ModalFooter, Form, FormGroup } from "reactstrap"
import {BsFillPencilFill} from 'react-icons/bs'



export const CharacterDetails = ({character, isOpen, updateIsOpen, updateEdit, edit, handleKeyPress, handleDelete}) =>{

    return (
      <>
        <Modal
          size="xl"
          style={{ width: "75rem", height: "34.375rem" }}
          isOpen={isOpen}
          backdrop={true}
          toggle={() => updateIsOpen(!isOpen)}
          className="character-modal container-sm"
        >
          <ModalBody className="new-char-sheet">
            <div className="new-char-form-container container-md-sm row">
              <div
                class="character-img col-md-3"
                style={{
                  backgroundImage: `url(/images/${character?.characterProfession.characterProfession.toLowerCase()}-symbol.svg)`,
                }}
              >
                {/* <img src={`/images/monk-symbol.svg`}/> */}
              </div>
              <div className="col-md-3 m-2">
                <div row>
                  {edit ? (
                    <input
                      type="text"
                      id="characterName"
                      autoFocus
                      className="col-md-auto"
                      defaultValue={character?.characterName}
                      onKeyDown={handleKeyPress}
                      onChange={(e) =>
                        (character.characterName = e.target.value)
                      }
                    />
                  ) : (
                    <div className="col-md-auto">
                      {character?.characterName}
                    </div>
                  )}
                  {edit ? (
                    ""
                  ) : (
                    <span
                      className="col-md-auto"
                      style={{ cursor: "pointer" }}
                      onClick={() => updateEdit(!edit)}
                    >
                      <BsFillPencilFill />
                    </span>
                  )}
                </div>
                <div row>
                  <p>Race: {character?.characterRace?.characterRace}</p>
                </div>
                <div row>
                  <p>
                    Class: {character?.characterProfession?.characterProfession}
                  </p>
                </div>
                <div row>
                  <p>
                    Alignment:{" "}
                    {character?.characterAlignment?.characterAlignment}{" "}
                  </p>
                </div>
                <div></div>
              </div>
              <div className="trait-drive-quirk-div col">
                <div className="traits-group">
                  <h3>Flaws</h3>
                  <p>
                    <strong>Flaw: </strong>{" "}
                    {character?.flaw?.flawCharacteristic}
                  </p>
                  <p>
                    <strong>Afraid of: </strong>
                    {character?.fear?.fearCharacteristic}
                  </p>
                  <p>
                    <strong>When stressed your character is: </strong>
                    {character?.stress?.stressedCharacteristic}
                  </p>
                </div>
                <div className="drive-group">
                  <h3>Drive</h3>
                  <p>
                    <strong>Your character is driven by a need to:</strong>{" "}
                    {character.characterDrive}
                  </p>
                </div>
                <div className="quirks-group">
                  <h3>Quirks</h3>
                  <ul>
                    <li>{character.quirkOne}</li>
                    <li>{character.quirkTwo}</li>
                    <li>{character.quirkThree}</li>
                  </ul>
                </div>
                <div>
                  <Button className="btn btn-danger" onClick={handleDelete}>
                    Delete
                  </Button>
                </div>
              </div>
            </div>
          </ModalBody>
        </Modal>
      </>
    );
}