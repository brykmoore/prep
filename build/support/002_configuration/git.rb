configs ={
  :git => {
    :provider => 'github',
    :user => 'remoteoctober2014',
    :remotes => %w/mangler brykmoore srinissn/,
    :repo => 'prep' 
  }
}
configatron.configure_from_hash(configs)
